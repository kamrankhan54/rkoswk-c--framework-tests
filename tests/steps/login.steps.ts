import { createBdd } from 'playwright-bdd';
import { test } from '../support/fixtures';
import data from '../data/data.json';

const { Given, When, Then } = createBdd(test);

Given('I open the login page', async ({login}) => {
  await login.open();
});

When('I enter my {string} username and password', async ({login}, username: string) => {
    await login.login(username, data.password);
});

Then('I should be logged in successfully', async ({ login }) => {
    await login.expectOnInventoryPage();
  });

Then('I should not be logged in and see locked out message', async ({ login }) => {
  await login.expectErrorVisible('Epic sadface: Sorry, this user has been locked out.');
});
