import { Page, Locator, expect } from '@playwright/test';
import data from '../data/data.json';

export class LoginPage {

  constructor(private page: Page) {}

  async open() {
    await this.page.goto(data.loginPage);
  }
  
  usernameInput() { return this.page.locator('input[data-test="username"]'); }
  passwordInput() { return this.page.locator('input[data-test="password"]'); }
  loginButton()   { return this.page.locator('input[data-test="login-button"]'); }
  errorMessage()  { return this.page.locator('[data-test="error"]'); }

  async login(username: string, password: string) {
    await this.usernameInput().fill(username);
    await this.passwordInput().fill(password);
    await this.loginButton().click();
  }

  async expectErrorVisible(error: string) {
    await expect(this.errorMessage()).toContainText(error);
  }

  async expectOnInventoryPage() {
    await expect(this.page).toHaveURL(/inventory\.html/);
  }
}
