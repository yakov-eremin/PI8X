import TimerManager from "./TimerManager.js";


describe('Проверки менеджера таймеров', () => {
	it('Объект менеджера создаётся', () => {
		const managerCallback = jest.fn()
		const tm = new TimerManager(managerCallback);
		expect(tm).toBeTruthy();
	})

	it('Метод addTimer создаёт таймер и сохраняет его в менеджере', () => {
		const managerCallback = jest.fn()
		const tm = new TimerManager(managerCallback);

		tm.addTimer('Тестовый таймер', 0, 10, 0, 0);

		expect(tm.getTimersData()[0]).toBe({name: 'Тестовый таймер', triggered: false, soundIndex: 0, h: 10, m: 0, s: 0})
	})

	it('Все таймеры, по мере срабатывания, отмечаются как triggered', () => {
		jest.useFakeTimers()

		const managerCallback = jest.fn()
		const tm = new TimerManager(managerCallback);

		const currentDate = new Date();
		const hour =  currentDate.getHours(), minute = currentDate.getMinutes(), second = currentDate.getSeconds();

		tm.addTimer('Тестовый таймер 1', 0, hour, minute + 1, second);
		tm.addTimer('Тестовый таймер 2', 0, hour, minute + 2, second);
		tm.addTimer('Тестовый таймер 3', 0, hour, minute + 3, second);

		expect(tm.getTimersData()).toBe([
			{name: 'Тестовый таймер1', triggered: false, soundIndex: 0, h: hour, m: minute + 1, s: second},
			{name: 'Тестовый таймер2', triggered: false, soundIndex: 0, h: hour, m: minute + 2, s: second},
			{name: 'Тестовый таймер3', triggered: false, soundIndex: 0, h: hour, m: minute + 3, s: second}
		])

		jest.advanceTimersByTime(60100);
		expect(tm.getTimersData()).toBe([
			{name: 'Тестовый таймер1', triggered: true, soundIndex: 0, h: hour, m: minute + 1, s: second},
			{name: 'Тестовый таймер2', triggered: false, soundIndex: 0, h: hour, m: minute + 2, s: second},
			{name: 'Тестовый таймер3', triggered: false, soundIndex: 0, h: hour, m: minute + 3, s: second}
		])

		jest.advanceTimersByTime(60100);
		expect(tm.getTimersData()).toBe([
			{name: 'Тестовый таймер1', triggered: true, soundIndex: 0, h: hour, m: minute + 1, s: second},
			{name: 'Тестовый таймер2', triggered: true, soundIndex: 0, h: hour, m: minute + 2, s: second},
			{name: 'Тестовый таймер3', triggered: false, soundIndex: 0, h: hour, m: minute + 3, s: second}
		])

		jest.advanceTimersByTime(60100);
		expect(tm.getTimersData()).toBe([
			{name: 'Тестовый таймер1', triggered: true, soundIndex: 0, h: hour, m: minute + 1, s: second},
			{name: 'Тестовый таймер2', triggered: true, soundIndex: 0, h: hour, m: minute + 2, s: second},
			{name: 'Тестовый таймер3', triggered: true, soundIndex: 0, h: hour, m: minute + 3, s: second}
		])
	})

	it('После срабатывания, вызывается коллбэк менеджера с индексом таймера', () => {
		jest.useFakeTimers()

		const managerCallback = jest.fn();
		const tm = new TimerManager(managerCallback);

		const currentDate = new Date();
		const hour =  currentDate.getHours(), minute = currentDate.getMinutes(), second = currentDate.getSeconds();

		tm.addTimer('Тестовый таймер 1', 0, hour, minute + 1, second);
		jest.advanceTimersByTime(60100);

		expect(managerCallback).toBeCalledTimes(1);
		expect(managerCallback).toBeCalledWith(0);
	})

	it('Метод removeTimer удаляет таймер по заданному индексу', () => {
		const managerCallback = jest.fn()
		const tm = new TimerManager(managerCallback);

		tm.addTimer('Тестовый таймер1', 0, 10, 0, 0);
		tm.addTimer('Тестовый таймер2', 0, 10, 0, 0);

		tm.removeTimer(0);
		expect(tm.getTimersData).toBe({name: 'Тестовый таймер2', soundIndex: 0, triggered: false,  h: 10, m: 0, s: 0});
	})

})