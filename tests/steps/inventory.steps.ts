import { createBdd } from 'playwright-bdd';
import { test, expect } from '../support/fixtures';

const { Given, When, Then } = createBdd(test);

Given('I add {string} product to cart', async ({ inventory }, name: string) => {
  await inventory.addItemToBasket(name);
});

When('I sort products by {string}', async ({ inventory }, order: string) => {
  await inventory.sortBy(order);
});

Then('Products should be ordered by {string}', async ({ inventory }, order: string) => {
  await inventory.orderedProducts(order);
});

Then('The inventory should have all items displayed', async ({ inventory }) => {
  await expect(inventory.inventoryItem()).toHaveCount(6);
});
