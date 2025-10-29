import { defineConfig, devices } from '@playwright/test';
import { defineBddConfig } from 'playwright-bdd';

// I've added this to use in a script that runs tests headless
const isHeadless = process.env.HEADLESS !== 'false'; 

const testDir = defineBddConfig({
  features: 'tests/features/**/*.feature',
  steps: [
    'tests/steps/**/*.ts',
    'tests/support/fixtures.ts'
  ],
});

export default defineConfig({
  testDir,
  reporter: 'html',
  use: {
    headless: isHeadless,
    trace: 'retain-on-failure',
    screenshot: 'only-on-failure',
    video: 'retain-on-failure'
  },
  projects: [
    { name: 'chromium', use: { ...devices['Desktop Chrome'] } },
    { name: 'firefox',  use: { ...devices['Desktop Firefox'] } },
    { name: 'safari',   use: { ...devices['Desktop Safari'] } },
  ],
  retries: 0
});
