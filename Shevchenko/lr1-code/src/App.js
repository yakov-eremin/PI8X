import logo from './logo.svg';
import './App.css';
import { React, useEffect, useState } from 'react';
import _ from 'lodash';
import { LineChart, Line, XAxis, YAxis } from 'recharts';
import ReactSlider from 'react-slider'

const jpeg = require('jpeg-js');

function App() {
  const [picDimensions, setPicDimensions] = useState({width: 1, height: 1});
  const [brightnessData, setBrightnessData] = useState([]);
  const [brightMod, setBrightnessModifiers] = useState({R:0, G:0, B:0})
  const [contrastMod, setContrastMod] = useState(1)
  const [pixelsData, setPixelsData] = useState(null)
  const loadImageToCanvas = (canvas, imageData, width, height) => {
    const ctx = canvas.getContext('2d');
        canvas.width = width;
        canvas.height = height;
        // create imageData object
        var idata = ctx.createImageData(width, height);
        // set our buffer as source
        idata.data.set(imageData);
        // update canvas with new data
        ctx.putImageData(idata, 0, 0);
  }
  const calculateHistogram = (pixelsArray) => {
    let result = [];
    pixelsArray.forEach(pixel => {
      let brightness = Math.round(0.299 * pixel[0] + 0.5876 * pixel[1] + 0.114 * pixel[2]);
      let index = _.findIndex(result, (elem) => elem.value === brightness );
      if (index === -1) {
        result.push({value: brightness, count: 0});
        index = result.length - 1;
      }
      result[index].count++;
    });
    return(_.sortBy(result, [(elem) => elem.value]))
  };

  useEffect(() => {
    fetch('pic.jpg').then(response => {
      const reader = response.body.getReader();
      reader.read().then(({done, value}) => {
        if (done) {
          reader.close();
          return; 
        }
        const rawImageData = jpeg.decode(value);
        console.log(`Image dimensions are ${rawImageData.width} by ${rawImageData.height}`);
        setPicDimensions({width: rawImageData.width, height: rawImageData.height})
        let pixels = [];
        for (let i = 0; i < rawImageData.data.length; i = i + 4) {
          pixels.push([rawImageData.data[i], rawImageData.data[i + 1], rawImageData.data[i + 2], rawImageData.data[i + 3]]);
        }

        setPixelsData(pixels);
        setBrightnessData(calculateHistogram(pixels));
        console.log(rawImageData.data)
        const canvas = document.getElementById('app__given-image-canvas');
        loadImageToCanvas(canvas, rawImageData.data, rawImageData.width, rawImageData.height);
      })
    })
  }, []);

  useEffect(() => {
    if (!pixelsData) {
      return;
    }

    let mod = pixelsData.map(pixel => {
      let pixelCopy = JSON.parse(JSON.stringify(pixel));
      pixelCopy[0] += brightMod.R;
      if (pixelCopy[0] < 0) pixelCopy[0] = 0;
      if (pixelCopy[0] > 255) pixelCopy[0] = 255;
      pixelCopy[1] += brightMod.G;
      if (pixelCopy[1] < 0) pixelCopy[1] = 0;
      if (pixelCopy[0] > 255) pixelCopy[0] = 255;
      pixelCopy[2] += brightMod.B;
      if (pixelCopy[2] < 0) pixelCopy[2] = 0;
      if (pixelCopy[0] > 255) pixelCopy[0] = 255;
      return pixelCopy;
    });
    const canvas = document.getElementById('app__mod-image-canvas');
    loadImageToCanvas(canvas, mod.flat(), picDimensions.width, picDimensions.height);
    setBrightnessData(calculateHistogram(mod));
  }, [brightMod, picDimensions, pixelsData]);
  
  useEffect(() => {
    if (!pixelsData) {
      return;
    }
    let mean = [0, 0, 0];
    pixelsData.forEach(pixel => {
      mean[0] += pixel[0];
      mean[1] += pixel[1];
      mean[2] += pixel[2];

    });
    
    mean = [Math.round(mean[0] / pixelsData.length),
            Math.round(mean[1] / pixelsData.length),
            Math.round(mean[2] / pixelsData.length)];

    let mod = pixelsData.map(pixel => {
      pixel[0] = Math.round(contrastMod * (pixel[0] - mean[0]) + mean[0]);
      if (pixel[0] < 0) pixel[0] = 0;
      if (pixel[0] > 255) pixel[0] = 255;
      pixel[1] = Math.round(contrastMod * (pixel[1] - mean[1]) + mean[1]);
      if (pixel[1] < 0) pixel[1] = 0;
      if (pixel[1] > 255) pixel[1] = 255;
      pixel[2] = Math.round(contrastMod * (pixel[2] - mean[2]) + mean[2]);
      if (pixel[2] < 0) pixel[2] = 0;
      if (pixel[2] > 255) pixel[2] = 255;
      return pixel;
    })
    
    const canvas = document.getElementById('app__mod-image-canvas');
    loadImageToCanvas(canvas, mod.flat(), picDimensions.width, picDimensions.height);
    setBrightnessData(calculateHistogram(mod));
  }, [contrastMod, picDimensions, pixelsData]);

  const makeBlackWhite = () => {
    let mod = pixelsData.map(pixel => {
      if (pixel[0] + pixel[1] + pixel[2] < 382) {
        pixel[0] = 0;
        pixel[1] = 0;
        pixel[2] = 0;
      } else {
        pixel[0] = 255;
        pixel[1] = 255;
        pixel[2] = 255;
      }
      return pixel;
    });
    const canvas = document.getElementById('app__mod-image-canvas');
    loadImageToCanvas(canvas, mod.flat(), picDimensions.width, picDimensions.height);
  }

  const makeNegative = () => {
    let mod = pixelsData.map(pixel => {
      pixel[0] = 255 - pixel[0];
      pixel[1] = 255 - pixel[1];
      pixel[2] = 255 - pixel[2];
      return pixel;
    });
    const canvas = document.getElementById('app__mod-image-canvas');
    loadImageToCanvas(canvas, mod.flat(), picDimensions.width, picDimensions.height);
  }
  const makeGrey = () => {
    let mod = pixelsData.map(pixel => {
      let brightness = Math.round(0.299 * pixel[0] + 0.5876 * pixel[1] + 0.114 * pixel[2]);
      pixel[0] = brightness;
      pixel[1] = brightness;
      pixel[2] = brightness;
      return pixel;
    });
    const canvas = document.getElementById('app__mod-image-canvas');
    loadImageToCanvas(canvas, mod.flat(), picDimensions.width, picDimensions.height);
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      
      <div style={{display: 'inline-block'}}>
        <h3>Оригинальное изображение</h3>
        <canvas id="app__given-image-canvas"/>
      </div>
      <div style={{display: 'inline-block'}}>
        <h3>Модифицированное изображение</h3>
        <canvas id="app__mod-image-canvas"/>
      </div>  
      <div/>
      <div style={{display: 'inline-block'}}>
        <h3>Гистограмма яркости</h3>
        <LineChart width={400} height={400} data={brightnessData}>
          <XAxis/>
          <YAxis/>
          <Line type="monotone" dataKey="count" stroke="#8884d8" />
        </LineChart>
      </div> 

      <div style={{display: 'inline-block'}}>
        <h3>{`Модификатор яркости: ${brightMod.R}:${brightMod.G}:${brightMod.B}`}</h3>
        <h3>Яркость R</h3>
        <button onClick={() => setBrightnessModifiers({R: brightMod.R + 1, G: brightMod.G, B: brightMod.B})}>+1</button>
        <button onClick={() => setBrightnessModifiers({R: brightMod.R - 1, G: brightMod.G, B: brightMod.B})}>-1</button>
        <h3>Яркость G</h3>
        <button onClick={() => setBrightnessModifiers({R: brightMod.R, G: brightMod.G + 1, B: brightMod.B})}>+1</button>
        <button onClick={() => setBrightnessModifiers({R: brightMod.R, G: brightMod.G - 1, B: brightMod.B})}>-1</button>
        <h3>Яркость B</h3>
        <button onClick={() => setBrightnessModifiers({R: brightMod.R, G: brightMod.G, B: brightMod.B + 1})}>+1</button>
        <button onClick={() => setBrightnessModifiers({R: brightMod.R, G: brightMod.G, B: brightMod.B - 1})}>-1</button>
        <h3>{`Модификатор контрастности: ${contrastMod}`}</h3>
        <button onClick={() => setContrastMod(contrastMod + 0.1)}>+0.1</button>
        <button onClick={() => setContrastMod(contrastMod - 0.1)}>-0.1</button>
        <h3>Прочее</h3>
        <button onClick={makeBlackWhite}>В Ч/Б</button>
        <button onClick={makeGrey}>В серость</button>
        <button onClick={makeNegative}>В негатив</button>
      </div>

      
    </div>
  );
}

export default App;
