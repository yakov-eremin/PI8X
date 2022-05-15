import Timer from './Timer'

describe('Проверки таймера', () => {
	it('Объект таймера создаётся', () => {
		const newTimer = new Timer();
		expect(newTimer).toBeTruthy();
	})

	it('Таймер выставляется с правильной задержкой', () => {
		jest.spyOn(global, 'setTimeout');
		const callback = jest.fn();

		const targetDate = new Date();

		const newTimer = new Timer('test timer', 0, callback, targetDate.getHours(), targetDate.getMinutes(), targetDate.getSeconds() + 1);
		expect(setTimeout).toHaveBeenCalledTimes(1);
		expect(setTimeout).toHaveBeenCalledWith(expect.any(Function), 1000);
	})

	it('Коллбэк таймера не вызывается раньше времени', () => {
		jest.spyOn(global, 'setTimeout');
		jest.useFakeTimers()
		const callback = jest.fn();
		const targetDate = new Date();

		const newTimer = new Timer('test timer', 0, callback, targetDate.getHours(), targetDate.getMinutes(), targetDate.getSeconds() + 1);
		jest.advanceTimersByTime(990);
		expect(callback).not.toHaveBeenCalled();
	})

	it('Метод getDisplayInfo возвращает объект с данными таймера', () => {
		const callback = jest.fn();
		const newTimer = new Timer('test timer', 0, callback, 0, 0, 1);
		expect(newTimer.getDisplayInfo()).toStrictEqual({
			name: 'test timer',
			triggered: false,
			soundIndex: 0,
			h: 0,
			m: 0,
			s: 1})
	})

	it('После срабатывания таймера вызывается коллбэк и таймер помечается как сработавший', () => {
		jest.useFakeTimers()
		const callback = jest.fn();
		const targetDate = new Date();

		const newTimer = new Timer('test timer', 0, callback, targetDate.getHours(), targetDate.getMinutes(), targetDate.getSeconds() + 1);
		jest.advanceTimersByTime(1100);
		expect(callback).toHaveBeenCalledTimes(1);
		expect(newTimer.getDisplayInfo()).toStrictEqual({
			name: 'test timer',
			triggered: true,
			soundIndex: 0,
			h: targetDate.getHours(),
			m: targetDate.getMinutes(),
			s: targetDate.getSeconds() + 1})
	})

})