import { createBdd } from 'playwright-bdd';
import { test, expect } from '../support/fixtures';
import data from '../data/data.json';

const { Given, When, Then } = createBdd(test);

Given('Complete my information using first name {string} last name {string} postcode {string}', async (
    { checkout }, firstName: string, lastName: string, postcode: string) => {
  await checkout.completeInfo(firstName, lastName, postcode);
  await checkout.clickContinue();
});

When('I click continue', async ({ checkout }) => {
  await checkout.clickContinue();
})

When('I click finish', async ({ checkout }) => {
  await checkout.clickFinish();
})

Then('The checkout overview page is displayed for {string} product', async ({ checkout }, productName: string) => {
    const product = data.products[0];
    const actualTitle = (await checkout.productTitle().innerText()).trim();
    const actualTotal = (await checkout.total().innerText()).trim();
    expect(actualTitle).toBe(product.title);
    expect(actualTotal).toBe(product.total);
});

Then('The thank for your order page is displayed', async ({ checkout }) => {
  const msg = await checkout.thankYouMessage().textContent();
  expect(msg).toBe('Thank you for your order!');
});
