import {QueueEntry} from './QueueEntry';

export interface QueueGet {
    id: number;
    timeStamp: string;
    queue: QueueEntry[];
  }
