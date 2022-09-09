import { combineReducers } from "redux";
import { missionReducer } from "./missionReducer";

export const rootReducer = combineReducers({
	mission: missionReducer



})


export type RootState = ReturnType<typeof rootReducer>