import { combineReducers } from "redux";

import { missionReducer } from "./missionReducer";
import { userReducer } from "./userReducer";

export const rootReducer = combineReducers({
	mission: missionReducer,
	user: userReducer,




})


export type RootState = ReturnType<typeof rootReducer>