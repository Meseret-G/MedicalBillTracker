
import React, { useState } from 'react'
import {
    Button  
  } from "reactstrap";
  //import SearchIcon from '@mui/icons-material/Search';

export default function SearchBill({  func, placeholder, data }) {
    const [wordEntered, setWordEntered] = useState('');
    const filteredData = () => data?.filter((bills) => bills.title.toLowerCase().includes(wordEntered.toLowerCase()) || bills.provider.toLowerCase().includes(wordEntered.toLowerCase()));
    
    const handleSearch = (e) => {
        const searchWord = e.target.value;
        setWordEntered(searchWord);

        if (searchWord === '') {
            func({});
        } else {
            func(filteredData);
        }
    };

  return (
    <>
 
          <div className="searchInputs"  >
            <input 
            style={{height: "40px", width: "300px", borderRadius:  "6px 6px 6px 6px", paddingLeft:"3.5rem"}}
              value = {wordEntered}
              placeholder={placeholder}
              onChange={handleSearch}
            />
            <Button type='button'
            className = 'search-button'
            >
              Search
            </Button>
           
            {/* <SearchIcon /> */}                 
          </div>
    </>
  )
}
