import React from 'react';
import { Spinner } from 'reactstrap';
import { signInUser } from '../Data/UserData';

export default function SignIn({ user }) {
  return (
    <>
      {user === null ? (
        <div className="text-center">
          <Spinner style={{ width: '8rem', height: '8rem' }} color="warning" />
        </div>
      ) : (
        <div className="text-center mt-5">
          <h1 className="welcome-page">Welcome To Medical Bill Tracker!</h1>
          <h1 className="welcome-page">Please Sign In Below</h1>
          <button type="button" className="btn btn-info" onClick={signInUser}>
            Sign In
          </button>
        </div>
     
      )}
       </>
  );
 }



