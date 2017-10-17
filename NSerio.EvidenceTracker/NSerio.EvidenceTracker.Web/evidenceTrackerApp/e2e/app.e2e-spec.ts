import { EvidenceTrackerAppPage } from './app.po';

describe('evidence-tracker-app App', () => {
  let page: EvidenceTrackerAppPage;

  beforeEach(() => {
    page = new EvidenceTrackerAppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
