
import auth from './auth/firebaseConfig';
import { getAuth, signInWithPopup, GoogleAuthProvider} from 'firebase/auth';

//const baseURL = 'https://localhost:7033/api';

// const getPatientbyId = (id) =>
//   new Promise((resolve, reject) => {
//     axios
//       .get(`${baseURL}/Patient/${id}`)
//       .then((response) => resolve(response.data))
//       .catch(reject);
//   });
  //Checks if patient exists on login using token. If patient does not exists, create patient.
 
 
  //  const patientExistsInDB = async () => {
  //   const token = sessionStorage.getItem('token');
  //   await axios.get(`${baseURL}/Patient/Auth`, {
  //     headers: { Authorization: 'Bearer ' + token },
  //   });
  // };
  
  const signInUser = async () => {
    const provider = await new GoogleAuthProvider();
    signInWithPopup(auth, provider);
  };
  const signOutUser = () =>
    new Promise((resolve, reject) => {
      getAuth().signOut().then(resolve).catch(reject);    
    });


export { signInUser, signOutUser } ;
