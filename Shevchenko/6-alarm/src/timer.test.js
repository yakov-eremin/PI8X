import Timer from './Timer'

describe('Проверки таймера', () => {
	it('Объект таймера создаётся', () => {
		const newTimer = new Timer();
		expect(newTimer).toBeTruthy();
	})

	it('Таймер выставляется с правильной задержкой', () => {
		jest.spyOn(global, 'setTimeout');
		const callback = jest.fn();
		const newTimer = new Timer('test timer', 1000, 0, callback);
		expect(setTimeout).toHaveBeenCalledTimes(1);
		expect(setTimeout).toHaveBeenCalledWith(expect.any(Function), 1000);
	})

	it('Коллбэк таймера не вызывается раньше времени', () => {
		jest.spyOn(global, 'setTimeout');
		jest.useFakeTimers()
		const callback = jest.fn();
		const newTimer = new Timer('test timer', 1000, 0, callback);
		jest.advanceTimersByTime(990);
		expect(callback).not.toHaveBeenCalled();
	})

	it('Коллбэк передаёт объект таймера', () => {
		const callback = jest.fn();
		jest.useFakeTimers()
		const newTimer = new Timer('test timer', 1000, 0, callback);
		jest.advanceTimersByTime(1100);
		expect(callback).toBeCalledWith(newTimer)
	})

})