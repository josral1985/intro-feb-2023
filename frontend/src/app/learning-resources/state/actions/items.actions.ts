import { createActionGroup, props } from '@ngrx/store';
import { ItemEntity } from '../reducers/items.reducers';

export const itemsEvents = createActionGroup({
  source: 'Items Events',
  events: {
    created: props<{ payload: ItemCreate }>(),
  },
});

export const itemsDocuments = createActionGroup({
  source: 'Items Documents',
  events: {
    items: props<{ payload: ItemEntity[] }>(),
    item: props<{ payload: ItemEntity }>(),
  },
});

export type ItemCreate = Omit<ItemEntity, 'id'>; //omit the id since it comes from the API
