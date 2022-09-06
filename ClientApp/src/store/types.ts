import { List } from "reactstrap";
import { Role } from "../enums/Role";

interface IUser {
	id: number;
	name: string;
	email: string;
	Role: Role

}


export interface Mission {
	id: number;
	name: string;
	description: string;
	startTime?: Date;
	endTime?: Date;
	fromUser: IUser;
	toUsers: Array<IUser>;
	fromUserId: number;


}