import { Page, expect } from '@playwright/test';
import { productSlug } from '../support/utils';

export class InventoryPage {
  constructor(private page: Page) {};

  inventoryList() { return this.page.locator('[data-test="inventory-list"]') }
  inventoryItem() { return this.page.locator('[data-test="inventory-item"]') }
  inventoryItemTitle() { return this.page.locator('[data-test="inventory-item-name"]') }
  inventoryItemDescriptin() { return this.page.locator('[data-test="inventory-item-desc"]') }
  inventoryItemPrice() { return this.page.locator('[data-test="inventory-item-price"]') }
  inventoryItemImage(productName: string) { return this.page.locator(`[data-test="inventory-item-${productName}-img"]`) }
  inventoryItemAddToBasket(productName: string) { return this.page.locator(`[data-test="add-to-cart-${productName}"]`) }
  removeProduct(name: string) { return this.page.locator(`[data-test="remove-${name}"]`) }
  
  async addItemToBasket(name: string) {
    const slug = productSlug(name);
    const addButton = this.inventoryItemAddToBasket(slug);
    await expect(addButton).toBeVisible();
    await addButton.click();
  }

  async removeItem(name: string) {
    const slug = productSlug(name);
    const removeButton = this.removeProduct(slug);
    await expect(removeButton).toBeVisible();
    await removeButton.click();
  }
}
