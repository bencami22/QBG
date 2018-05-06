import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { QueueService } from '../queue.service';
import { QueueGet } from '../QueueGet';
import {QueueEnqueueComponent} from '../queue-enqueue/queue-enqueue.component';

@Component({
  selector: 'app-queues-view',
  templateUrl: './queues-view.component.html',
  providers: [QueueService]
})
export class QueuesViewComponent {

  private queue: QueueGet;
  private current: string;

  constructor(private route: ActivatedRoute,
    private queueService: QueueService) { }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit(): void {
    this.getQueue();
  }

  getQueue(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.queueService.getQueue(id)
      .subscribe(queue => {
      this.queue = queue;
      if (queue.queue) {
        this.current = this.queue.queue[0].username;
      }
      });
  }
}
