import { createBdd } from 'playwright-bdd';
import { test, expect } from '../support/fixtures';

const { Given, When, Then } = createBdd(test);

Given('I go to the {string} product page', async ({ product }, name: string) => {
  await product.viewProductPage(name);
});

Given('I add product to cart', async ({ product }, name: string) => {
  await product.addItemToBasket();
});
