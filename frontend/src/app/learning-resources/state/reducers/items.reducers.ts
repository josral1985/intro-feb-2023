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

export interface ItemState extends EntityState<ItemEntity> {} //extends the EntityState interface, alt + f12 for implementation

export const adapter = createEntityAdapter<ItemEntity>(); //creates the output; using the ngrx entity helper function
// since the data from API is an array/not as "simple" as the counter, where we just created an interface

const initialState = adapter.getInitialState(); //initial state

export const reducer = createReducer(
  initialState,
  on(itemsDocuments.items, (s, a) => adapter.setAll(a.payload, s)),
  on(itemsDocuments.item, (s, a) => adapter.addOne(a.payload, s))
);
