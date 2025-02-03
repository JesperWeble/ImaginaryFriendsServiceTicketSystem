export interface Ticket {
  id: number;
  title: string;
  description: string;
  customerId: number;
  userId: number;
  updatedAt: Date;
  statusId: number;
  levelId: number;
}
