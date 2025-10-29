import { Page, expect } from "@playwright/test";

export class CheckoutPages {
  constructor(private page: Page) {};

  // Step 1 checkout locators
  firstName() { return this.page.locator('[data-test="firstName"]') }
  lastName() { return this.page.locator('[data-test="lastName"]') }
  postcode() { return this.page.locator('[data-test="postalCode"]') }
  continue() { return this.page.locator('[data-test="continue"]') }

  // Step 2 checkout locators
  productName() { return this.page.locator('[data-test="inventory-item-name"]') }
  productDescription() { return this.page.locator('[data-test="inventory-item-name"]') }
  productTitle() { return this.page.locator('[data-test="inventory-item-name"]') }
  paymentInfoValue() { return this.page.locator('[data-test="payment-info-value"]') }
  shippingInfoValue() { return this.page.locator('[data-test="shipping-info-value"]') }
  subtotal() { return this.page.locator('[data-test="subtotal-label"]') }
  tax() { return this.page.locator('[data-test="tax-label"]') }
  total() { return this.page.locator('[data-test="total-label"]') }
  finishButton() { return this.page.locator('[data-test="finish"]') }

  // Step 3 checkout 
  thankYouMessage() { return this.page.locator('[data-test="complete-header"]') }

  // Step 1 checkout
  async completeInfo(firstName: string, lastName: string, postcode: string) {
    await expect(this.firstName()).toBeVisible();
    await this.firstName().fill(firstName);
    await this.lastName().fill(lastName);
    await this.postcode().fill(postcode);
  }

  // Step 1 checkout
  async clickContinue() {
    await expect(this.continue()).toBeVisible();
    this.continue().click();
  }

  // Step 2 checkout
  async clickFinish() {
    await expect(this.finishButton()).toBeVisible();
    this.finishButton().click();
  }
}
