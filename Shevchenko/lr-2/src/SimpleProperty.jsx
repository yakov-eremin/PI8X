import {TextField} from "@mui/material";
import React, {useState, useEffect} from "react";

const SimpleProperty = ({id, label, name, value, readOnly, updateCallback}) => {

  const [currVal, setVal] = useState('');
  useEffect(() => {
    setVal(value)
  }, [value])
  return(
    <input
      onBlur={() => updateCallback({target: {value: currVal, name: name}})}
      onChange={(event) => {
        setVal(event.target.value)
      }}
      // sx={{marginBottom: '1rem'}}
      id={id + '-input'}
      // label={label}
      name={name}
      readOnly={readOnly}
      // inputProps={{'readOnly': readOnly}}
      value={currVal}
      size='small'
      // multiline
    />
  )
}

export default SimpleProperty;