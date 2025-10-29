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
  productSortDropdown() { return this.page.locator('[data-test="product-sort-container"]'); }
  
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

  async sortBy(name: string) {
    await this.productSortDropdown().selectOption({ label: name});
  }

  async orderedProducts(order: string) {
    const prices = await this.inventoryItemPrice().allInnerTexts(); 
    const numeric = prices.map(p => parseFloat(p.replace('$','')));
    expect(numeric).toEqual([...numeric].sort((a, b) => b - a));
  }
}
