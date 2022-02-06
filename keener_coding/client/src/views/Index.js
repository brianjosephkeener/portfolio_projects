import React from 'react'

const Index = (props) => {
  return (
    <div>
      <div className="zindex top-page">
        <h1 className='text-center w'>Hey, I'm <span className='text-primary'>Brian</span>.</h1>
        <h1 className='text-center w'>I'm a fullstack web developer.</h1>
        <button className='btn btn-danger center-me mt'><a href='https://github.com/Skull86' target={"_blank"}>View my Work</a></button>
      </div>
      <div className='logo-container mt'>
        <div className='logo-row mt'>
          <img src='images\c-logo.png' alt='C# logo'></img>
          <img src='images\python-logo.png' alt='python logo'></img>
          <img src='images\flask.jpg' alt='react logo'></img>
          <img src='images\react-png.png' alt='react logo'></img>
          
          </div>
        <div className='logo-row mt'>
          <img src='images\mongodb-logo.png' alt='mongodb logo' id='mongoDB'></img>
          <img src='images\mysql-logo.png' alt='mysql logo'></img>
          </div>
        <div className='logo-row mt'>
        <img src='images\javascript-logo.png' alt='javascript logo'></img>
          <img src='images\html-logo.png' alt='html logo'></img>
          <img src='images\css-logo.png' alt='css logo'></img>
        </div>
      </div>
    </div>
  );
}
    
export default Index;