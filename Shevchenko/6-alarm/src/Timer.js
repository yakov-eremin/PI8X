class Timer {
	constructor(name, delay, soundIndex, callback) {
		this.name = name;
		this.delay = delay;
		this.soundIndex = soundIndex;
		this.callBack = callback;

		setTimeout(() => callback(this), delay);
	}
}

export default Timer;