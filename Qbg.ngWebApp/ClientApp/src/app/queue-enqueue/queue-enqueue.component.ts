import { Component, OnInit, Input, Output } from '@angular/core';

import { QueueService } from '../queue.service';
import { QueueGet } from '../QueueGet';
import { EventEmitter } from 'events';


@Component({
  selector: 'app-queue-enqueue',
  templateUrl: './queue-enqueue.component.html',
  styleUrls: ['./queue-enqueue.component.css']
})
export class QueueEnqueueComponent implements OnInit {
  @Input() queueId: number;
  @Input() queueGet: QueueGet;
  @Input() current: string;
  @Output() queueGetChange: EventEmitter = new EventEmitter();
  @Output() currentVarChange: EventEmitter = new EventEmitter();
  constructor(private queueService: QueueService) { }

  ngOnInit() {
  }

  add(username: string) {
    this.queueService.enqueue(this.queueId, username)
      .subscribe(result => {
        console.log('successfully enqueued ' + username);
        this.queueService.getQueue(this.queueId)
          .subscribe(queue => {
            this.queueGet = queue;
            if (queue.queue) {
              this.current = queue.queue[0].username;
            }
          });
      },
        error => {
          console.error(error);
        });
  }
}
