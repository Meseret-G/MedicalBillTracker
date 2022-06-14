import React , {useState, useEffect }from 'react';
import { useParams, useNavigate } from 'react-router-dom';
//import auth from '../Data/auth/firebaseConfig';
import { createBill, getBillById, updateBill } from '../Data/BilllData';




const initialState = {
  title: '',
  provider: '',
  imageURL: '',
  outOfPocket : '',
  date: '',
  personalNote: '',
  isArchived: false
  
};

export default function BillForm() {
  const [formInput, setFormInput] = useState({});
  //const [uid, setUid] = useState(null);
  const { dbKey } = useParams();

  //const currentPatient = getPatientbyId

  const navigate = useNavigate();

  useEffect(() => {

    if (dbKey) {
      getBillById(dbKey).then((obj) => {
        setFormInput({
          id: obj?.dbKey,
          title: obj?.title,
          provider: obj?.provider,
          imageURL: obj?.imageURL,
          outOfPocket: obj?.outOfPocket, 
          date: obj.date,
          personalNote: obj.personalNote,
           isArchived: false      
             
        });
      });
    } else {
      // const currentUid = auth.currentUser?.uid;
      // console.warn(currentUid.name);
      // setUid(currentUid);

      setFormInput({
        title: '',
      provider: '',
      imageURL: '',
      outOfPocket : '',
      //date: new Date().toDateString(),
      date:'',
      personalNote: '',
      isArchived: false });
    }
  }, []);

  const handleChange = (e) => {
    //const { name, value } = e.target;
    setFormInput((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value,
    }));
  };

  const resetForm = () => {   
    setFormInput({ ...initialState });
  };

  const handleSubmit = (e) => {
    e.preventDefault();  
    if (dbKey) {
      updateBill(dbKey, formInput).then(() => {
        resetForm()
        navigate('/');
      }) 
    
    } else 
    {

    
      createBill({...formInput}).then(() => {
        resetForm();
        navigate('/');
      });    

    }
  };

    return (
            
        <div className="form-box">
      <h3>Bill Form</h3>
      <form onSubmit={handleSubmit}>
        <div className="input-fields">
        <label className='form-label' htmlFor="bill">
                Don't forget. Add it now!
            </label>
          <input
            type='text'
            className='form-control'
            name='title'
            value={formInput.title || ''}
            onChange={handleChange}
            placeholder='Bill Title'
            required
          />  
          <input
            type='text'
            className='form-control'
            name='provider'
            value={formInput.provider || ''}
            onChange={handleChange}
            placeholder='Bill Provider'
            required
          />           
          <input
            type='text'
            className='form-control'
            name='date'
            value={formInput.date || ''}
            onChange={handleChange}
            placeholder='Service Date'
            required
          />    
          <input
            type='url'
            className='form-control'
            name='imageURL'
            value={formInput.imageURL || ''}
            onChange={handleChange}
            placeholder=' Image URL'
            
          />
       
          <input
            type='number'
            className='form-control'
            name='outOfPocket'
            value={formInput.outOfPocket || ''}
            onChange={handleChange}
            placeholder='How much you paid out of pocket'
            required
          />
            <textarea
            type='text'
            className='form-control'
            name='personalNote'
            value={formInput.personalNote || ''}
            onChange={handleChange}
            placeholder='Add comment'
          />     
        <button className='addUpdate-button' type='submit'>
          {dbKey ? 'Update' : 'Submit'}
        </button>
        </div>
      </form>   
      </div>
    
  );
}
