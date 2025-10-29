import { createBdd } from 'playwright-bdd';
import { test } from '../support/fixtures';

const { Given, When, Then } = createBdd(test);

Given('I add {string} product to cart', async ({inventory}, name: string) => {
  await inventory.addItemToBasket(name);
});