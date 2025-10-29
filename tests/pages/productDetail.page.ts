import { Page, expect } from '@playwright/test';
import { productSlug } from '../support/utils';

export class ProductDetailPage {
  constructor(private page: Page) {};

  addToBasket() { return this.page.locator('[data-test="add-to-cart"]') }
  
  async addItemToBasket() {
    await this.addToBasket().click();
  }

  async viewProductPage(name: string) {
    await this.page.locator('[data-test="inventory-item-name"]', { hasText: name }).click();
  }
}
