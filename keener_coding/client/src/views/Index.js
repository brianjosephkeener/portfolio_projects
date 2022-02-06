import React from 'react'


const Index = (props) => {
  return (
    <div>
      <div className="zindex top-page">
        <h1 className='text-center w'>Hey, I'm <span className='text-primary'>Brian</span>.</h1>
        <h1 className='text-center w'>I'm a fullstack web developer.</h1>
        <button className='btn btn-danger center-me'>View my Work</button>
      </div>
      <div className='next-project'>
        <h2 className='text-center w'>C# Frontend and Backend Re-Design of Local Business</h2>
        <div className='present-container mt'>
          <img src='images\gym-before.png' className='gym-b'></img>
          <h2 className='w ml mb'>Before Re-Design</h2>
        </div>
      </div>
    </div>
  );
}
    
export default Index;