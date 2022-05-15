import {deltaTime} from "./commons";

it('deltaTime functions works correctly', () => {
	const timeA = new Date();
	timeA.setHours(0);
	timeA.setMinutes(0);
	timeA.setSeconds(0);

	const timeB = new Date();
	timeB.setHours(1);
	timeB.setMinutes(0);
	timeB.setSeconds(0);

	expect(deltaTime(timeA, timeB)).toBe(3600000)
})