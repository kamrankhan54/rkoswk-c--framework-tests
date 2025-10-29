import { createBdd } from 'playwright-bdd';
import { test, expect } from '../support/fixtures';

const { Given, When, Then } = createBdd(test);

Given('I open the cart page', async ({ cart }) => {
  await cart.open();
})

When('I click checkout', async ({ cart }) => {
  await cart.clickCheckout();
})

Given('I remove {string} product from cart', async ({ cart }, name: string) => {
  await cart.removeItem(name);
})

Then('The cart page should be empty', async ({ cart }) => {
  await expect(cart.inventoryItem()).toHaveCount(0);
});

Then('The cart should have {int} items', async ({ cart }, itemCount: number) => {
  await expect(cart.inventoryItem()).toHaveCount(itemCount);
});

Then('The product in cart should be {string}', async ({ cart }, name: string) => {
  const productName = await cart.itemName().textContent();
  expect(productName).toBe(name);
});
