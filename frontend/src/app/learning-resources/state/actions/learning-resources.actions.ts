import { createActionGroup, emptyProps } from '@ngrx/store';

export const learningResourcesEvents = createActionGroup({
  source: 'Learning Resources Events',
  events: {
    entered: emptyProps(),
  },
});
