import React from 'react'
import axios from 'axios';
import {Link} from "react-router-dom";
    
const PetList = (props) => {

    const { removeFromDom } = props;

    return (
        <div>
            <h1>Pet Shelter:</h1>
            <h2>These pets are looking for a good home</h2>
            {props.pet.map((pet, i) => {
                return <p key={i}>
                    <h2>{pet.name}</h2>
                    <h2>{pet.type}</h2>
                    <button><Link to={pet._id}> Details</Link></button>
                    |
                    <button><Link to={"/pet/" + pet._id + "/edit"}> Edit</Link></button>
                </p>
            })}
        </div>
        
    )
}
    
export default PetList;

