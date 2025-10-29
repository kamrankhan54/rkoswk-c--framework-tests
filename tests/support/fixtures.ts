import { test as base } from 'playwright-bdd';
import { LoginPage } from '../pages/login.page';
import { CartPage } from '../pages/cart.page';
import { InventoryPage } from '../pages/inventory.page';

type Fixtures = {
  login: LoginPage;
  cart: CartPage;
  inventory: InventoryPage;
};

export const test = base.extend<Fixtures>({
  login: async ({ page }, use) => {
    const login = new LoginPage(page);
    await use(login);
  },
  cart: async ({ page }, use) => {
    const cart = new CartPage(page);
    await use(cart);
  },
  inventory: async ({ page }, use) => {
    const inventory = new InventoryPage(page);
    await use(inventory);
  }
});

export { expect } from '@playwright/test';
