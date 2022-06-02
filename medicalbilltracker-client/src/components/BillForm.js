import React , {useState, useEffect }from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { createBill, getBillById, updateBill } from '../Data/BilllData';



const initialState = {
  title: '',
  provider: '',
  imageURL: '',
  outOfPocket : '',
};

export default function BillForm() {
  const [formInput, setFormInput] = useState({});
  const { dbKey } = useParams();

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
        });
      });
    } else {
      setFormInput(initialState);
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
      });
    }
      createBill({...formInput }).then(() => {
        resetForm();
        navigate('/');
      });    
  };

    return (
        
        <>
      <h3>Bill Form</h3>
      <form onSubmit={handleSubmit}>
        <div>
        <label className='form-label' htmlFor="rent">
                Bill Title:
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
        </div>
        <div>
        <label className='form-label' htmlFor="rent">
               Provider Name:
            </label>
          <input
            type='text'
            className='form-control'
            name='provider'
            value={formInput.provider || ''}
            onChange={handleChange}
            placeholder='Bill Provider'
            required
          />
        </div>
            
        <div>
        <label className='form-label' htmlFor="rent">
                Image:
            </label>
          <input
            type='url'
            className='form-control'
            name='imageURL'
            value={formInput.imageURL || ''}
            onChange={handleChange}
            placeholder='Image'
            
          />
        </div>
        <div>
        <label className='form-label' htmlFor="rent">
                Out of Pocket
            </label>
          <input
            type='number'
            className='form-control'
            name='outOfPocket'
            value={formInput.outOfPocket || ''}
            onChange={handleChange}
            placeholder='Out of Pocket'
            required
          />
        </div> 
        <button className='addUpdate-button' type='submit'>
          {dbKey ? 'Update' : 'Submit'}
        </button>
      </form>
    </>
  );
}
