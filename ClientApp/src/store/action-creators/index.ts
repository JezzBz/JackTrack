import * as MissionActionCreators from './mission'
import * as UserActionCreators from './user'
import * as AuthActionCreators from './auth'

export default {
	...MissionActionCreators,
	...UserActionCreators,
	...AuthActionCreators
}