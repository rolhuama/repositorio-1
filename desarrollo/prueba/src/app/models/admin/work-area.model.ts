import { WorkAreaTeam } from "./work-area-team.model";

export class WorkArea {
    id!: number;
    code!: string | null;
    name!: string;
    teams: WorkAreaTeam[] = [];
}
