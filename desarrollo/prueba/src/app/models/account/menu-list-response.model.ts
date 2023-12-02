import { MenuGroup } from "./menu-group.model";
import { Menu } from "./menu.model";

export class MenuListResponse {
    groups: MenuGroup[] = [];
    links: Menu[] = [];
}
