import './App.css';
import React, {useState, useEffect, useCallback, useRef} from 'react';
import TimerManager from "./TimerManager";

import {SOUND_NAMES} from "./constants";

function App() {
  const [newTimerData, setNewTimerData] = useState({h: 0, m: 0, s: 0, name: '', soundIndex: 0});
  const handleNewTimerDataUpdate = (event) => {
    setNewTimerData({...newTimerData, [event.target.name]: event.target.value})
  }

  const [timersData, setTimersData] = useState([]);
  const updateTimers = (index) => {
    const newData = managerRef.current.getTimersData()
    if (index !== -1) {
      console.log('сработал таймер! ' + index)
      console.log('Играет ' + SOUND_NAMES[newData[index].soundIndex])
    }

    setTimersData(newData);
  }
  const updateTrigger = useCallback((index) => {updateTimers(index)}, [])
  const managerRef = useRef(new TimerManager(updateTrigger));

  const handleAddTimer = () => {
    managerRef.current.addTimer(newTimerData.name, newTimerData.soundIndex, newTimerData.h, newTimerData.m, newTimerData.s)
  }

  return (
    <div className="App">
      <h3>Менеджер будильников</h3>
      <div style={{display: 'flex', flexDirection: 'row', width: '100hv'}}>
        <div style={{display: 'flex', flexDirection: 'column'}}>
          <p>Список будильников:</p>
          {timersData.map((timer, key) => (
            <div style={{border: `2px solid ${timer.triggered ? 'red' : 'black'}`, marginBottom: '1em'}}>
              <p>{timer.name}</p>
              <p>{`Звук - ${SOUND_NAMES[timer.soundIndex]}`}</p>
              <p>{`Время срабатывания - ${timer.h}:${timer.m}:${timer.s}`}</p>
              <button onClick={() => managerRef.current.removeTimer(key)}>удалить</button>
            </div>
          ))}
        </div>
        <div style={{display: 'flex', flexDirection: 'column'}}>
          <p>Новый будильник</p>
          <form style={{display: 'flex', flexDirection: 'column', alignItems: 'flex-start'}}>
            <label>
              Название
              <input
                type='text'
                name='name'
                value={newTimerData.name}
                onChange={handleNewTimerDataUpdate}
              />
            </label>
            <label>
              Время (ЧЧ:ММ:СС)
              <input type='number' min={0} max={23} name='h' value={newTimerData.h} onChange={handleNewTimerDataUpdate}/>
              <input type='number' min={0} max={59} name='m' value={newTimerData.m} onChange={handleNewTimerDataUpdate}/>
              <input type='number' min={0} max={59} name='s' value={newTimerData.s} onChange={handleNewTimerDataUpdate}/>
            </label>
            <label>
              Мелодия
              <select value={newTimerData.soundIndex} onChange={handleNewTimerDataUpdate}>
                {SOUND_NAMES.map((name, key) => <option value={key}>{name}</option> )}
              </select>
            </label>
          </form>
          <button onClick={handleAddTimer}>Добавить будильник</button>
        </div>
      </div>
    </div>
  );
}

export default App;
