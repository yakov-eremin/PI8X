import Timer from './Timer';

class TimerManager {
	#timers;
	#updateCallback;

	constructor(callbackFn) {
		this.#timers = [];
		this.#updateCallback = callbackFn;
	}

	addTimer(timerName, soundIndex, h, m, s) {
		const index = this.#timers.length
		this.#timers.push(new Timer(timerName, soundIndex, () => this.#updateCallback(index), h, m, s))
	}
	getTimersData() {
		return this.#timers.map(timer => timer.getDisplayInfo())
	}
	removeTimer(timerIndex) {
		this.#timers[timerIndex].clearTimer();
		this.#timers.splice(timerIndex, 1);
		this.#updateCallback(-1);
	}
}

export default TimerManager;