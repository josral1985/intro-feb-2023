import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromItems from './reducers/items.reducers';
export const featureName = 'resources';

export interface FeatureInterface {
  items: fromItems.ItemState;
}

export const reducers: ActionReducerMap<FeatureInterface> = {
  items: fromItems.reducer,
};

// 1. feature select - get the feature (we have counter and resources; here we get resources)
const selectFeature = createFeatureSelector<FeatureInterface>(featureName);

// 2. Selector per branch of the feature (1 - items)
// "Functional Composition"
//we select the "branch" from the feature, here we got Items
const selectItemsBranch = createSelector(selectFeature, (f) => f.items);

// 3. Helpers
//getting ALL items from the feature>items and rename selectItemsArray
//selectAll is a helper selector

// 4. What our component needs.
export const { selectAll: selectItemsArray } =
  fromItems.adapter.getSelectors(selectItemsBranch);
