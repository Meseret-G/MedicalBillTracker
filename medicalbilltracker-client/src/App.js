/* eslint-disable react-hooks/exhaustive-deps */
import React from 'react';
import './styles/index.scss';
import Navbar from './components/Navbar';
import AppRoutes from './routes';
// import auth from './Data/auth/apiKey';
// import { useNavigate } from 'react-router-dom';
// import { patientExistsInDB } from './Data/PatientData';

function App() {
  // const [ patient, setPatient] = useState(null);
  // const navigate = useNavigate();

  // useEffect(() => {
  //   auth.onAuthStateChanged(async (authed) => {
  //     if(authed) {
  //       const patientObj = {
  //         Name: authed.displayName,
  //         uid: authed.uid,
  //         //profilePic: authed.photoURL,
  //         //username: authed.email.split('@')[0],
  //         accessToken: authed.accessToken,
  //       };
  //       setPatient(patientObj);
  //       sessionStorage.setItem("idToken", authed.accessToken);
  //       sessionStorage.setItem("uid", authed.uid);
  //       patientExistsInDB(authed.accessToken).then(setPatient(patientObj));
  //     } else {
    
  //       setPatient(false);
  //       sessionStorage.removeItem("idToken");
  //       navigate('/');
  //     }
  //   });
  // }, []);

  return (
    <div className="App" >
      <Navbar />  
        <AppRoutes  />
      </div>
  
  );
}

export default App;
