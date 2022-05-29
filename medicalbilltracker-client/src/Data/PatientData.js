import axios from 'axios';
import auth from './auth/apiKey';
import { getAuth, signInWithPopup, GoogleAuthProvider} from 'firebase/auth';

const baseURL = 'https://localhost:7033/api';


  //Checks if patient exists on login using token. If patient does not exists, create patient.
 
 
  const patientExistsInDB = async () => {
    const token = sessionStorage.getItem('idToken');
    await axios.get(`${baseURL}/Patient/Auth`, {
      headers: { Authorization: 'Bearer ' + token, idToken: token },
    });
  };
  
  const signInPatient = async () => {
    const provider = await new GoogleAuthProvider();
    signInWithPopup(auth, provider);
  };
  const signOutPatient = () =>
    new Promise((resolve, reject) => {
      getAuth().signOut().then(resolve).catch(reject);    
    });


export { patientExistsInDB, signInPatient,signOutPatient };
