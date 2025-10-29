import { Page, expect } from "@playwright/test";
import data from '../data/data.json';
import { productSlug } from '../support/utils';

export class CartPage {
  constructor(private page: Page) {};

  async open() {
    await this.page.goto(data.cartPage);
  }

  inventoryItem() { return this.page.locator('[data-test="inventory-item"]') }
  itemName() { return this.page.locator('[data-test="inventory-item-name"]') }
  removeProduct(name: string) { return this.page.locator(`[data-test="remove-${name}"]`) }

  async removeItem(name: string) {
    const slug = productSlug(name);
    const removeButton = this.removeProduct(slug);
    await expect(removeButton).toBeVisible();
    await removeButton.click();
  }
}
