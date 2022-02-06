import React from 'react'

const Index = (props) => {
  return (
    <div>
      <div className="zindex top-page">
        <h1 className='text-center w'>Hey, I'm <span className='text-primary'>Brian</span>.</h1>
        <h1 className='text-center w'>I'm a fullstack web developer.</h1>
        <button className='btn btn-danger center-me'>View my Work</button>
      </div>
      <div>
      <img src='images\c-logo.png' alt='C# logo'></img>
      <img src='images\mongodb-logo.png' alt='mongodb logo'></img>
      <img src='images\mysql-logo.png' alt='mysql logo'></img>
      <img src='images\python-logo.png' alt='python logo'></img>
      <img src='images\react-png.png' alt='react logo'></img>
      <img src='images\javascript-logo.png' alt='javascript logo'></img>
      <img src='images\html-logo.png' alt='html logo'></img>
      <img src='images\css-logo.png' alt='css logo'></img>
      </div>
    </div>
  );
}
    
export default Index;