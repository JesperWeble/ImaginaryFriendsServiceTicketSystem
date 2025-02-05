export interface FullTicketInfoDto {
    id: number;
    title: string;
    description: string;
    updatedAt: Date;
    customer: CustomerDto;
    user: UserDto;
    level: LevelDto;
    status: StatusDto;
}

export interface CustomerDto {
    id: number;
    fName: string;
    lName: string;
    sla: SlaDto;
}

export interface UserDto {
    id: number;
    name: string;
}

export interface LevelDto {
    id: number;
    name: string;
}

export interface StatusDto {
    id: number;
    name: string;
}

export interface SlaDto {
    slaId: number;
    name: string;
}
