import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { itemsDocuments } from '../actions/items.actions';

export interface ItemEntity {
  id: string;
  description: string;
  type: ItemType;
  link: string;
}

export type ItemType = 'Book' | 'Video' | 'Blog' | 'Tutorial' | 'Other';

export interface ItemState extends EntityState<ItemEntity> {}

export const adapter = createEntityAdapter<ItemEntity>(); //creates the output

const initialState = adapter.getInitialState(); //initial state

export const reducer = createReducer(
  initialState,
  on(itemsDocuments.items, (s, a) => adapter.setAll(a.payload, s))
);
