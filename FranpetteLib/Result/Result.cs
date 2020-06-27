using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Result
{
    public class Result
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }

        public Result(bool success)
        {
            this.Success = success;
        }

        public Result(bool success, string error) : this(success)
        {
            this.Error = error;
        }


        public static implicit operator bool(Result result)
        {
            return result.Success;
        }

        public void Reevaluate<T>(ref Result updated, T additionalConsideration) where T : Result
        {
            if (!additionalConsideration)
            {
                if (this)
                {
                    updated = additionalConsideration;
                    return;
                }
                else
                {
                    updated.Error = updated ? additionalConsideration.Error : string.Join("; ", updated.Error, additionalConsideration.Error);
                }
            }

            updated = this;
        }
    }

    public class FailResult : Result
    {
        public FailResult() : base(false)
        {
        }

        public FailResult(string error) : base(false, error)
        {
        }
    }

    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public static DataResult<T> WithData<T>(T data)
        {
            return new DataResult<T>(data);
        }
    }

    public class DataResult<T> : SuccessResult
    {
        public DataResult(T obj)
        {
            this.Data = obj;
        }

        public T Data { get; private set; }
    }
}
