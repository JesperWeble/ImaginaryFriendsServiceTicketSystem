export interface Ticket {
  id: number;
  title: string;
  description: string;
  customerId: number;
  userId: number;
  updated_at: Date;
  statusId: number;
  levelId: number;
}
