import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { QueueService } from '../queue.service';
import { QueueGet } from '../QueueGet';
import { QueueEnqueueComponent } from '../queue-enqueue/queue-enqueue.component';

@Component({
  selector: 'app-queues-view',
  templateUrl: './queues-view.component.html',
  providers: [QueueService]
})
export class QueuesViewComponent {

  private queueId: number;
  private queueGet: QueueGet;
  private current: string;

  constructor(private route: ActivatedRoute,
    private queueService: QueueService) { }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit(): void {
    this.queueId = +this.route.snapshot.paramMap.get('id');
    this.getQueue();
  }

  getQueue(): void {
    this.refresh();
  }

  enqueueSuccess(username: string) {
    this.refresh();
  }

  dequeue(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.queueService.dequeue(id).subscribe(result => {
      this.refresh();
    },
      error => { console.error(error); });
  }

  refresh(): void {
    this.queueService.getQueue(this.queueId)
      .subscribe(queue => {
        this.queueGet = queue;
        if (queue.queue && queue.queue.length > 0) {
          this.current = queue.queue[0].username;
        }
      });
  }
}
