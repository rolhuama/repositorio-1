import { MenuGroup } from "./menu-group.model";

export class Menu {
    id!: number;
    name!: string;
    url!: string;
    icon!: string;
    order!: number;
    groupId!: number;
    group: MenuGroup = new MenuGroup;
}
