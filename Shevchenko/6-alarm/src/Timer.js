class Timer {
	#name;
	#soundIndex;
	#triggered;
	#hours;
	#minutes;
	#seconds;
	#timeoutId;

	constructor(name, soundIndex, callback, h, m, s) {
		this.#name = name;
		this.#soundIndex = soundIndex;
		this.#triggered = false;
		this.#hours = h;
		this.#minutes = m;
		this.#seconds = s;

		const currDate = new Date()

		const targetDate = new Date();
		targetDate.setHours(h, m, s);

		this.#timeoutId = setTimeout(() => {
			this.#triggered = true;
			callback();
			}, Math.abs(currDate - targetDate));
	}

	getDisplayInfo() {
		return({
			name: this.#name,
			triggered: this.#triggered,
			soundIndex: this.#soundIndex,
			h: this.#hours,
			m: this.#minutes,
			s: this.#seconds,
		})
	}

	clearTimer() {
		clearTimeout(this.#timeoutId);
	}
}

export default Timer;