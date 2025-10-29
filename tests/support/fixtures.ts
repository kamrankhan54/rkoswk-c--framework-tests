import { test as base } from 'playwright-bdd';
import { LoginPage } from '../pages/login.page';

type Fixtures = {
  login: LoginPage;
};

export const test = base.extend<Fixtures>({
  login: async ({ page }, use) => {
    const login = new LoginPage(page);
    await use(login);
  }
});
