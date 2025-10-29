/**
 * Converts a product name like "Sauce Labs Backpack"
 * into a slug like "sauce-labs-backpack"
 */
export function productSlug(name: string): string {
  return name
    .toLowerCase()
    .trim()
    .replace(/\s+/g, '-');
}
